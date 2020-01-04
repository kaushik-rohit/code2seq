public CAS process(String text) {
        CAS cas = retrieve();

        cas.setDocumentText(text);
        try {
            analysisEngine.process(cas);
        } catch (AnalysisEngineProcessException e) {
            if (text != null && !text.isEmpty())
                return process(text);
            throw new RuntimeException(e);
        }

        return cas;


    }