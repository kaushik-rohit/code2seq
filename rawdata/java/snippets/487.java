private MessageType getReadSchema(MessageType fileSchema, Path filePath) {
		RowTypeInfo fileTypeInfo = (RowTypeInfo) ParquetSchemaConverter.fromParquetType(fileSchema);
		List<Type> types = new ArrayList<>();
		for (int i = 0; i < fieldNames.length; ++i) {
			String readFieldName = fieldNames[i];
			TypeInformation<?> readFieldType = fieldTypes[i];
			if (fileTypeInfo.getFieldIndex(readFieldName) < 0) {
				if (!skipWrongSchemaFileSplit) {
					throw new IllegalArgumentException("Field " + readFieldName + " cannot be found in schema of "
						+ " Parquet file: " + filePath + ".");
				} else {
					this.skipThisSplit = true;
					return fileSchema;
				}
			}

			if (!readFieldType.equals(fileTypeInfo.getTypeAt(readFieldName))) {
				if (!skipWrongSchemaFileSplit) {
					throw new IllegalArgumentException("Expecting type " + readFieldType + " for field " + readFieldName
						+ " but found type " + fileTypeInfo.getTypeAt(readFieldName) + " in Parquet file: "
						+ filePath + ".");
				} else {
					this.skipThisSplit = true;
					return fileSchema;
				}
			}
			types.add(fileSchema.getType(readFieldName));
		}

		return new MessageType(fileSchema.getName(), types);
	}