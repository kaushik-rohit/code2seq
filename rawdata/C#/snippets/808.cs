public void Run ()
		{
			// -n, --ncb         Burn the contents of the burn:// URI
			// --immediately     Start burning immediately.
			// It seems like in past version --immediately was part of -n
			// Unfortunately, brasero (3.2) doesn't seem to clean up burn://
			// after a successful burn.
			ProcessStartInfo psi = new ProcessStartInfo (brasero_exec, "-n --immediately");
			Process.Start (psi);
		}