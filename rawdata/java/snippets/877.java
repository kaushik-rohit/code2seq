protected void renameTo(final String newName) throws IOException {
        // always synchronize from bigger objects first
        final ItemGroup parent = getParent();
        String oldName = this.name;
        String oldFullName = getFullName();
        synchronized (parent) {
            synchronized (this) {
                // sanity check
                if (newName == null)
                    throw new IllegalArgumentException("New name is not given");

                // noop?
                if (this.name.equals(newName))
                    return;

                // the lookup is case insensitive, so we should not fail if this item was the “existing” one
                // to allow people to rename "Foo" to "foo", for example.
                // see http://www.nabble.com/error-on-renaming-project-tt18061629.html
                Items.verifyItemDoesNotAlreadyExist(parent, newName, this);

                File oldRoot = this.getRootDir();

                doSetName(newName);
                File newRoot = this.getRootDir();

                boolean success = false;

                try {// rename data files
                    boolean interrupted = false;
                    boolean renamed = false;

                    // try to rename the job directory.
                    // this may fail on Windows due to some other processes
                    // accessing a file.
                    // so retry few times before we fall back to copy.
                    for (int retry = 0; retry < 5; retry++) {
                        if (oldRoot.renameTo(newRoot)) {
                            renamed = true;
                            break; // succeeded
                        }
                        try {
                            Thread.sleep(500);
                        } catch (InterruptedException e) {
                            // process the interruption later
                            interrupted = true;
                        }
                    }

                    if (interrupted)
                        Thread.currentThread().interrupt();

                    if (!renamed) {
                        // failed to rename. it must be that some lengthy
                        // process is going on
                        // to prevent a rename operation. So do a copy. Ideally
                        // we'd like to
                        // later delete the old copy, but we can't reliably do
                        // so, as before the VM
                        // shuts down there might be a new job created under the
                        // old name.
                        Copy cp = new Copy();
                        cp.setProject(new org.apache.tools.ant.Project());
                        cp.setTodir(newRoot);
                        FileSet src = new FileSet();
                        src.setDir(oldRoot);
                        cp.addFileset(src);
                        cp.setOverwrite(true);
                        cp.setPreserveLastModified(true);
                        cp.setFailOnError(false); // keep going even if
                                                    // there's an error
                        cp.execute();

                        // try to delete as much as possible
                        try {
                            Util.deleteRecursive(oldRoot);
                        } catch (IOException e) {
                            // but ignore the error, since we expect that
                            e.printStackTrace();
                        }
                    }

                    success = true;
                } finally {
                    // if failed, back out the rename.
                    if (!success)
                        doSetName(oldName);
                }

                parent.onRenamed(this, oldName, newName);
            }
        }
        ItemListener.fireLocationChange(this, oldFullName);
    }