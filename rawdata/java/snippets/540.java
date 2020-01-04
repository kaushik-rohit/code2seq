public static void removeBottomSeparators(JPopupMenu popupMenu) {
        int indexLastComponent = popupMenu.getComponentCount() - 1;
        while (indexLastComponent >= 0 && isPopupMenuSeparator(popupMenu.getComponent(indexLastComponent))) {
            popupMenu.remove(indexLastComponent);
            indexLastComponent -= 1;
        }
    }