private ModelAndView generateErrorView(final String code, final Object[] args) {
        val modelAndView = new ModelAndView(this.failureView);
        val convertedDescription = getMessageSourceAccessor().getMessage(code, args, code);
        modelAndView.addObject("code", StringEscapeUtils.escapeHtml4(code));
        modelAndView.addObject("description", StringEscapeUtils.escapeHtml4(convertedDescription));
        return modelAndView;
    }