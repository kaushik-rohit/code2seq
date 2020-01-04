@Override
    protected ModelAndView handleRequestInternal(final HttpServletRequest request, final HttpServletResponse response) throws Exception {
        for (val delegate : this.delegates) {
            if (delegate.canHandle(request, response)) {
                return delegate.handleRequestInternal(request, response);
            }
        }
        return generateErrorView(CasProtocolConstants.ERROR_CODE_INVALID_REQUEST, null);
    }