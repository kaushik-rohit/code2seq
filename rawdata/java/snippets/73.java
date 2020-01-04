public Map<String, AttributeValue> buildTableAttributeValuesMapFromTicket(final Ticket ticket, final Ticket encTicket) {
        val values = new HashMap<String, AttributeValue>();
        values.put(ColumnNames.ID.getColumnName(), new AttributeValue(encTicket.getId()));
        values.put(ColumnNames.PREFIX.getColumnName(), new AttributeValue(ticket.getPrefix()));
        values.put(ColumnNames.CREATION_TIME.getColumnName(), new AttributeValue(ticket.getCreationTime().toString()));
        values.put(ColumnNames.COUNT_OF_USES.getColumnName(), new AttributeValue().withN(Integer.toString(ticket.getCountOfUses())));
        values.put(ColumnNames.TIME_TO_LIVE.getColumnName(), new AttributeValue().withN(Long.toString(ticket.getExpirationPolicy().getTimeToLive())));
        values.put(ColumnNames.TIME_TO_IDLE.getColumnName(), new AttributeValue().withN(Long.toString(ticket.getExpirationPolicy().getTimeToIdle())));
        values.put(ColumnNames.ENCODED.getColumnName(), new AttributeValue().withB(ByteBuffer.wrap(SerializationUtils.serialize(encTicket))));
        LOGGER.debug("Created attribute values [{}] based on provided ticket [{}]", values, encTicket.getId());
        return values;
    }