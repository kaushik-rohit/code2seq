private void unmigrateBuildsDir(File builds) throws Exception {
        File mapFile = new File(builds, MAP_FILE);
        if (!mapFile.isFile()) {
            System.err.println(builds + " does not look to have been migrated yet; skipping");
            return;
        }
        for (File build : builds.listFiles()) {
            int number;
            try {
                number = Integer.parseInt(build.getName());
            } catch (NumberFormatException x) {
                continue;
            }
            File buildXml = new File(build, "build.xml");
            if (!buildXml.isFile()) {
                System.err.println(buildXml + " did not exist");
                continue;
            }
            String xml = FileUtils.readFileToString(buildXml, Charsets.UTF_8);
            Matcher m = TIMESTAMP_ELT.matcher(xml);
            if (!m.find()) {
                System.err.println(buildXml + " did not contain <timestamp> as expected");
                continue;
            }
            long timestamp = Long.parseLong(m.group(1));
            String nl = m.group(2);
            xml = m.replaceFirst("  <number>" + number + "</number>" + nl);
            m = ID_ELT.matcher(xml);
            String id;
            if (m.find()) {
                id = m.group(1);
                xml = m.replaceFirst("");
            } else {
                // Post-migration build. We give it a new ID based on its timestamp.
                id = legacyIdFormatter.format(new Date(timestamp));
            }
            FileUtils.write(buildXml, xml, Charsets.UTF_8);
            if (!build.renameTo(new File(builds, id))) {
                System.err.println(build + " could not be renamed");
            }
            Util.createSymlink(builds, id, Integer.toString(number), StreamTaskListener.fromStderr());
        }
        Util.deleteFile(mapFile);
        System.err.println(builds + " has been restored to its original format");
    }