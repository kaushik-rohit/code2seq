@Override
    public void delete(String id) throws SQLException {
        Connection c = dataSource.getConnection();
        PreparedStatement p = c.prepareStatement(deleteStatement());
        p.setString(1, id);
        p.execute();


    }