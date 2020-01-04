public String getResponseBaggage(String key) {
        if (BAGGAGE_ENABLE && key != null) {
            return responseBaggage.get(key);
        }
        return null;
    }