private void showLicense() {
        final LicenseFrame license = new LicenseFrame();
        license.setPostTask(new Runnable() {

            @Override
            public void run() {
                license.dispose();

                if (!license.isAccepted()) {
                    return;
                }

                createAcceptedLicenseFile();

                init(true);
            }
        });
        license.setVisible(true);
    }