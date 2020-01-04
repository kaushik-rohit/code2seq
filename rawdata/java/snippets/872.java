public InputStream generateImage() {
        if (closed) {
            throw new ActivitiImageException("ProcessDiagramGenerator already closed");
        }

        try {
            ByteArrayOutputStream stream = new ByteArrayOutputStream();
            Writer out;
            out = new OutputStreamWriter(stream,
                                         "UTF-8");
            g.stream(out,
                     true);
            return new ByteArrayInputStream(stream.toByteArray());
        } catch (UnsupportedEncodingException | SVGGraphics2DIOException e) {
            throw new ActivitiImageException("Error while generating process image",
                                             e);
        }
    }