@SuppressWarnings("unused") // expose utility check method to subclasses
    protected FormValidation checkDisplayName(@Nonnull View view, @CheckForNull String value) {
        if (StringUtils.isBlank(value)) {
            // no custom name, no need to check
            return FormValidation.ok();
        }
        for (View v: view.owner.getViews()) {
            if (v.getViewName().equals(view.getViewName())) {
                continue;
            }
            if (StringUtils.equals(v.getDisplayName(), value)) {
                return FormValidation.warning(Messages.View_DisplayNameNotUniqueWarning(value));
            }
        }
        return FormValidation.ok();
    }