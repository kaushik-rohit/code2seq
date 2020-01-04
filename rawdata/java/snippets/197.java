public static SameDiff restoreFromTrainingConfigZip(File file) throws IOException {
        ZipFile zipFile = new ZipFile(file);
        ZipEntry config = zipFile.getEntry(TRAINING_CONFIG_JSON_ZIP_ENTRY_NAME);
        TrainingConfig trainingConfig = null;
        try(InputStream stream = zipFile.getInputStream(config)) {
            byte[] read = IOUtils.toByteArray(stream);
            trainingConfig = ObjectMapperHolder.getJsonMapper().readValue(read,TrainingConfig.class);
        }

        SameDiff ret = null;

        ZipEntry sameDiffFile = zipFile.getEntry(SAMEDIFF_FILE_ENTRY_NAME);
        try(InputStream stream = zipFile.getInputStream(sameDiffFile)) {
            byte[] read = IOUtils.toByteArray(stream);
            ret = SameDiff.fromFlatBuffers(ByteBuffer.wrap(read));
        }


        ret.setTrainingConfig(trainingConfig);
        ret.initializeTraining();
        return ret;
    }