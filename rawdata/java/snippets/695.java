public SDVariable[] generateOutputVariableForOp(DifferentialFunction function, String baseName, boolean isImport) {
        //xyz ops only have 1 output
        //if there is already a base name defined, use that
        if (baseName == null || baseName.isEmpty() && getBaseNameForFunction(function) != null)
            baseName = getBaseNameForFunction(function);

        if (baseName == null)
            baseName = function.opName();

        //First: calculate output data types. We can always calculate output data types, even if the input arrays
        //are not available - *except for sometimes during import, until all ops/variables have been added*
        List<org.nd4j.linalg.api.buffer.DataType> outputDataTypes = null;

        if(!isImport) {
            List<org.nd4j.linalg.api.buffer.DataType> inputDataTypes = new ArrayList<>();
            List<String> fnInputs = ops.get(function.getOwnName()).getInputsToOp();
            if (fnInputs != null) {
                for (String var : fnInputs) {
                    inputDataTypes.add(variables.get(var).getVariable().dataType());
                }
            }
            outputDataTypes = function.calculateOutputDataTypes(inputDataTypes);
        }

        val outputShape = function.calculateOutputShape();
        if (outputShape == null || outputShape.isEmpty()) {
            if (function instanceof CustomOp) {
                CustomOp customOp = (CustomOp) function;
                //can't guess number of outputs, variable
                int num_outputs = function.getNumOutputs(); //Use this in preference - if set. Descriptor might specify 2, but it can sometimes be 2+
                if (num_outputs <= 0) {
                    val descriptor = customOp.getDescriptor();
                    if (descriptor != null) {
                        num_outputs = descriptor.getNumOutputs();
                    }
                    if (num_outputs <= 0) {
                        throw new ND4UnresolvedOutputVariables("Could not determine number of output variables for op "
                                + function.getOwnName() + " - " + function.getClass().getSimpleName() + ". Ops can override" +
                                " getNumOutputs() to specify number of outputs if required");
                    }
                }
                char ordering = 'c';
                SDVariable[] args = function.args();
                if (args != null && args.length > 0 && args[0].getArr() != null) {  //Args may be null or length 0 for some ops, like eye
                    ordering = function.args()[0].getArr().ordering();
                }
                SDVariable[] ret = new SDVariable[num_outputs];

                //Infer the output types: we can always determine datatype but not always shapes
                Preconditions.checkState(isImport || num_outputs == 0 || (outputDataTypes != null && outputDataTypes.size() == num_outputs),
                        "Incorrect number of output datatypes: got %s but expected datatypes for %s outputs - %s (op: %s)",
                        (outputDataTypes == null ? null : outputDataTypes.size()), num_outputs, outputDataTypes, function.getClass().getSimpleName());

                //dynamic shapes
                //When importing from TF: convention is "unstack", "unstack:1", "unstack:2", ...
                for (int i = 0; i < ret.length; i++) {
                    SDVariable var = (i == 0 ? getVariable(baseName) : getVariable(baseName + ":" + i));
                    if (var == null) {
                        //Generate new variable name if one with the specified name doesn't exist
                        //Note: output of an op is ARRAY type - activations, not a trainable parameter. Thus has no weight init scheme

                        org.nd4j.linalg.api.buffer.DataType dataType  = isImport ? null : outputDataTypes.get(i);
                        var = var(generateNewVarName(baseName, i), VariableType.ARRAY, null, dataType, (long[])null);
                    }
                    var.setOutputIndex(i);
                    var.setCreator(function);
                    ret[i] = var;
                }

                //Update the internal state: outgoing variables for function
                if (getOutputsForFunction(function) == null)
                    addOutgoingFor(ret, function);

                return ret;
            }

            //this is for unresolved shapes, we know xyz is always 1 output
            else if (function instanceof BaseOp && outputShape.isEmpty()) {
                SDVariable[] ret = new SDVariable[1];
                SDVariable checkGet = getVariable(baseName);
                char ordering = 'c';
                SDVariable[] args = function.args();
                if (args != null && args.length > 0 && function.args()[0].getArr() != null) { //Args may be null or length 0 for some ops, like eye
                    ordering = function.args()[0].getArr().ordering();
                }
                if (checkGet == null) {
                    //Note: output of an op is ARRAY type - activations, not a trainable parameter. Thus has no weight init scheme
                    org.nd4j.linalg.api.buffer.DataType dataType  = outputDataTypes.get(0);
                    checkGet = var(baseName, VariableType.ARRAY, null, dataType, (long[])null);
                }

                if (checkGet == null) {
                    //Note: output of an op is ARRAY type - activations, not a trainable parameter. Thus has no weight init scheme
                    org.nd4j.linalg.api.buffer.DataType dataType  = outputDataTypes.get(0);
                    checkGet = var(baseName, VariableType.ARRAY, null, dataType, (long[])null);
                }

                checkGet.setOutputIndex(0);
                checkGet.setCreator(function);
                ret[0] = checkGet;


                //Update the internal state: outgoing variables for function
                if (getOutputsForFunction(function) == null)
                    addOutgoingFor(ret, function);

                return ret;
            }
        }

        //Check that output shapes and output dtypes actually match (they should)
        if(!isImport) {
            for (int i = 0; i < outputShape.size(); i++) {
                org.nd4j.linalg.api.buffer.DataType shapeDataType = outputShape.get(i).dataType();
                org.nd4j.linalg.api.buffer.DataType calcType = outputDataTypes.get(i);
                Preconditions.checkState(calcType == shapeDataType, "Calculated output data types do not match for shape calculation vs. datatype calculation:" +
                        " %s vs %s for op %s output %s", shapeDataType, calcType, function.getClass().getName(), i);
            }
        }

        char ordering = 'c';
        if (function.args() != null && function.args().length > 0 && function.args()[0].getArr() != null) {
            ordering = function.args()[0].getArr().ordering();
        }

        SDVariable[] ret = new SDVariable[outputShape.size()];

        // ownName/baseName will be used to get variables names
        val ownName = function.getOwnName();
        val rootName = baseName;
        for (int i = 0; i < ret.length; i++) {
            LongShapeDescriptor shape = outputShape.get(i);
            // it should be: rootName:index. i.e.: split:1, split:2, split:3, split:4 etc
            baseName = rootName + (i > 0 ? ":" + i : "");
            SDVariable checkGet = getVariable(baseName);
            if (checkGet == null) {
                // obviously - there's no such var, just add it
                //Note: output of an op is ARRAY type - activations, not a trainable parameter. Thus has no weight init scheme


                checkGet = var(baseName, VariableType.ARRAY, null, shape.dataType(), shape.getShape());
            } else if (shape != null && !shapeAlreadyExistsForVarName(checkGet.getVarName())) {
                // var exists, let's update its shape
                putShapeForVarName(checkGet.getVarName(), shape);
            } else if (shape != null && shapeAlreadyExistsForVarName(checkGet.getVarName())) {
                // no-op.
                // TODO: maybe we should check shapes equality here?
                // it's either var that already exist, or something bad happening
            }

            if (checkGet == null) {
                org.nd4j.linalg.api.buffer.DataType dataType = org.nd4j.linalg.api.buffer.DataType.FLOAT;     //TODO FIX THIS
                checkGet = var(baseName + (i > 0 ? ":" + i : ""), new ZeroInitScheme(ordering), dataType, shape.getShape());
            }

            checkGet.setOutputIndex(i);
            checkGet.setCreator(function);
            ret[i] = checkGet;
        }

        return ret;
    }