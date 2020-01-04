public List<Future<Boolean>> primeConnectionsAsync(final List<Server> servers, final PrimeConnectionListener listener) {
        if (servers == null) {
            return Collections.emptyList();
        }
        List<Server> allServers = new ArrayList<Server>();
        allServers.addAll(servers);
        if (allServers.size() == 0){
            logger.debug("RestClient:" + name + ". No nodes/servers to prime connections");
            return Collections.emptyList();
        }        

        logger.info("Priming Connections for RestClient:" + name
                + ", numServers:" + allServers.size());
        List<Future<Boolean>> ftList = new ArrayList<Future<Boolean>>();
        for (Server s : allServers) {
            // prevent the server to be used by load balancer
            // will be set to true when priming is done
            s.setReadyToServe(false);
            if (aSync) {
                Future<Boolean> ftC = null;
                try {
                    ftC = makeConnectionASync(s, listener);
                    ftList.add(ftC);
                }
                catch (RejectedExecutionException ree) {
                    logger.error("executor submit failed", ree);
                }
                catch (Exception e) {
                    logger.error("general error", e);
                    // It does not really matter if there was an exception,
                    // the goal here is to attempt "priming/opening" the route
                    // in ec2 .. actual http results do not matter
                }
            } else {
                connectToServer(s, listener);
            }
        }   
        return ftList;
    }