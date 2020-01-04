public void SetValueAndDefault( decimal value, decimal defaultValue )
        {
            if( Hexadecimal )
                FFTPatchEditor.ToolTip.SetToolTip( this, string.Format( "Default: 0x{0:X2}", (int)defaultValue ) );
            else
                FFTPatchEditor.ToolTip.SetToolTip( this, string.Format( "Default: {0}", defaultValue ) );
            
            DefaultValue = defaultValue;
            Value = value > Maximum ? Maximum : value;
            OnValueChanged( EventArgs.Empty );
        }