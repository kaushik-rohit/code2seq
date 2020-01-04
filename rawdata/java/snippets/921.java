public PythonDataStream<SingleOutputStreamOperator<PyObject>> map(
		MapFunction<PyObject, PyObject> mapper) throws IOException {
		return new PythonSingleOutputStreamOperator(stream.map(new PythonMapFunction(mapper)));
	}