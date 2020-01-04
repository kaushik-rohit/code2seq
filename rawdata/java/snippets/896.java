public boolean canAccept(WorkChunk c) {
            if (this.size()<c.size())
                return false;   // too small compared towork

            if (c.assignedLabel!=null && !c.assignedLabel.contains(node))
                return false;   // label mismatch

            if (!(Node.SKIP_BUILD_CHECK_ON_FLYWEIGHTS && item.task instanceof Queue.FlyweightTask) && !nodeAcl.hasPermission(item.authenticate(), Computer.BUILD))
                return false;   // tasks don't have a permission to run on this node

            return true;
        }