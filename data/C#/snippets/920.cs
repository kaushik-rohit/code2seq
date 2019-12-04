protected void UpdatePacket() {
      try { 
        int data_length = 0;
        bool write_cas = false;
        bool write_dhe = false;
        bool write_cert = false;
        bool write_hash = false;
        bool require_signature = true;

        switch(_type) {
          case MessageType.NoSuchSA:
            require_signature = false;
            break;
          case MessageType.Cookie:
            require_signature = false;
            break;
          case MessageType.CookieResponse:
            require_signature = false;
            data_length = 4 + _cas.Count * CALength;
            write_cas = true;
            break;
          case MessageType.DHEWithCertificate:
            data_length = 4 + _dhe.Length + 4 + _certificate.Length;
            write_cert = true;
            write_dhe = true;
            break;
          case MessageType.DHEWithCertificateAndCAs:
            data_length = 4 + _dhe.Length + 4 + _certificate.Length + 4 + _cas.Count * CALength;
            write_cas = true;
            write_dhe = true;
            write_cert = true;
            break;
          case MessageType.Confirm:
            data_length = 4 + _hash.Length;
            write_hash = true;
            break;
        }

        int length = 4 + 4 + 4 + 2 * CookieLength + data_length;
        if(require_signature) {
          length += _signature.Length;
        }
        byte[] b = new byte[length];
        int pos = 0;
        NumberSerializer.WriteInt(_version, b, pos);
        pos += 4;
        NumberSerializer.WriteInt(_spi, b, pos);
        pos += 4;
        NumberSerializer.WriteInt((int) _type, b, pos);
        pos += 4;
        if(_local_cookie == null) {
          EmptyCookie.CopyTo(b, pos);
        } else {
          _local_cookie.CopyTo(b, pos);
        }
        pos += CookieLength;
        if(_remote_cookie == null) {
          EmptyCookie.CopyTo(b, pos);
        } else {
          _remote_cookie.CopyTo(b, pos);
        }
        pos += CookieLength;
        
        if(write_dhe) {
          NumberSerializer.WriteInt(_dhe.Length, b, pos);
          pos += 4;
          _dhe.CopyTo(b, pos);
          pos += _dhe.Length;
        }

        if(write_cert) {
          NumberSerializer.WriteInt(_certificate.Length, b, pos);
          pos += 4;
          _certificate.CopyTo(b, pos);
          pos += _certificate.Length;
        }

        if(write_cas) {
          NumberSerializer.WriteInt(_cas.Count * CALength, b, pos);
          pos += 4;
          foreach(MemBlock ca in _cas) {
            ca.CopyTo(b, pos);
            pos += CALength;
          }
        }

        if(write_hash) {
          NumberSerializer.WriteInt(_hash.Length, b, pos);
          pos += 4;
          _hash.CopyTo(b, pos);
          pos += _hash.Length;
        }

        if(require_signature) {
          _signature.CopyTo(b, pos);
        }
        _packet = MemBlock.Reference(b);
      } catch(Exception e) {
        throw new Exception("Missing data for SecurityControlMessage!");
      }
      _update_packet = false;
    }