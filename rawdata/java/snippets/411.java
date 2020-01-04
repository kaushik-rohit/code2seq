public boolean isDone() {
    if (status() == Status.DONE) {
      return true;
    }
    ChangeRequest updated = reload(Dns.ChangeRequestOption.fields(Dns.ChangeRequestField.STATUS));
    return updated == null || updated.status() == Status.DONE;
  }