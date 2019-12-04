private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TextBoxLenght.Text) <= 0)
                {
                    throw new Exception("error");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Процесс сохранения прерван. В одном из полей недопустимые значения");
                return;
            }

            _wr.ColorBase = HostColorBase.Child.BackColor;
            _wr.Nperiod = Convert.ToInt32(TextBoxLenght.Text);
            if (CheckBoxPaintOnOff.IsChecked.HasValue)
            {
                _wr.PaintOn = CheckBoxPaintOnOff.IsChecked.Value;
            }
            

            _wr.Save();

            IsChange = true;
            Close();
        }