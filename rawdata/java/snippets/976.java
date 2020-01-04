@ExceptionHandler(UnrecognizedPropertyException.class)
    public ResponseEntity<?> handleUnrecognizedProperty(UnrecognizedPropertyException ex, HttpServletRequest request) {
        ErrorResponse response = new ErrorResponse();
        response.addFieldError(ex.getPropertyName(), ex.getMessage());
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(response);
    }