public NameID getNameID(final String nameIdFormat, final String nameIdValue) {
        val nameId = newSamlObject(NameID.class);
        nameId.setFormat(nameIdFormat);
        nameId.setValue(nameIdValue);
        return nameId;
    }