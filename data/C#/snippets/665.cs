private void InitTimecodeModes()
        {
            TimecodeModes = new ObservableCollection<TimecodeMode>
            {
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeRP188Any, Name = "RP188 Any"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeRP188LTC, Name = "RP188 LTC"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeRP188VITC1, Name = "RP188 VITC1"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeRP188VITC2, Name = "RP188 VITC2"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeVITC, Name = "VITC"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeVITCField2, Name = "VITC Field 2"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeSerial, Name = "Serial"},
                new TimecodeMode {Mode = _BMDTimecodeFormat.bmdTimecodeLTC, Name = "LTC"}
            };
        }