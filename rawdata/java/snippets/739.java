public Nature getNature()
    {
        Nature nature = Nature.nz;
        switch (nPOS)
        {
            case CharType.CT_CHINESE:
                break;
            case CharType.CT_NUM:
            case CharType.CT_INDEX:
            case CharType.CT_CNUM:
                nature = Nature.m;
                sWord = Predefine.TAG_NUMBER;
                break;
            case CharType.CT_DELIMITER:
                nature = Nature.w;
                break;
            case CharType.CT_LETTER:
                nature = Nature.nx;
                sWord = Predefine.TAG_CLUSTER;
                break;
            case CharType.CT_SINGLE://12021-2129-3121
                if (Predefine.PATTERN_FLOAT_NUMBER.matcher(sWord).matches())//匹配浮点数
                {
                    nature = Nature.m;
                    sWord = Predefine.TAG_NUMBER;
                } else
                {
                    nature = Nature.nx;
                    sWord = Predefine.TAG_CLUSTER;
                }
                break;
            default:
                break;
        }
        return nature;
    }