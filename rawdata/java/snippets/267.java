public INDArray exec(INDArray a, INDArray b, INDArray result) {
        a = transposeIfReq(transposeA, a);
        b = transposeIfReq(transposeB, b);
        if(result == null) {
            INDArray ret = a.mmul(b);
            return transposeIfReq(transposeResult, ret);
        } else {

            if(!transposeResult){
                return a.mmuli(b, result);
            } else {
                return a.mmuli(b, result).transpose();
            }
        }
    }