private boolean isAllSuitableNodesOffline(R build) {
        Label label = getAssignedLabel();
        List<Node> allNodes = Jenkins.getInstance().getNodes();

        if (label != null) {
            //Invalid label. Put in queue to make administrator fix
            if(label.getNodes().isEmpty()) {
                return false;
            }
            //Returns true, if all suitable nodes are offline
            return label.isOffline();
        } else {
            if(canRoam) {
                for (Node n : Jenkins.getInstance().getNodes()) {
                    Computer c = n.toComputer();
                    if (c != null && c.isOnline() && c.isAcceptingTasks() && n.getMode() == Mode.NORMAL) {
                        // Some executor is online that  is ready and this job can run anywhere
                        return false;
                    }
                }
                //We can roam, check that the master is set to be used as much as possible, and not tied jobs only.
                return Jenkins.getInstance().getMode() == Mode.EXCLUSIVE;
            }
        }
        return true;
    }