public final AutoBuffer writeJSON_impl( AutoBuffer ab ) {
    ab.putJSON("job", job);
    ab.put1(',');
    ab.putJSONStr("algo", algo);
    ab.put1(',');
    ab.putJSONStr("algo_full_name", algo_full_name);
    ab.put1(',');
    ab.putJSONAEnum("can_build", can_build);
    ab.put1(',');
    ab.putJSONEnum("visibility", visibility);
    ab.put1(',');
    ab.putJSONZ("supervised", supervised);
    ab.put1(',');
    ab.putJSONA("messages", messages);
    ab.put1(',');
    ab.putJSON4("error_count", error_count);
    ab.put1(',');

    // Builds ModelParameterSchemaV2 objects for each field, and then calls writeJSON on the array
    ModelParametersSchemaV3.writeParametersJSON(ab, parameters, createParametersSchema().fillFromImpl((Model.Parameters)parameters.createImpl()));
    return ab;
  }