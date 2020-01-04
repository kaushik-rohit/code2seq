public FlowVariable createFlowVariable(final Flow flow, final String id, final Class type) {
        val opt = Arrays.stream(flow.getVariables()).filter(v -> v.getName().equalsIgnoreCase(id)).findFirst();
        if (opt.isPresent()) {
            return opt.get();
        }
        val flowVar = new FlowVariable(id, new BeanFactoryVariableValueFactory(type, applicationContext.getAutowireCapableBeanFactory()));
        flow.addVariable(flowVar);
        return flowVar;
    }