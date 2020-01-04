public static void keyPressString(String str) {
		ClipboardUtil.setStr(str);
		keyPressWithCtrl(KeyEvent.VK_V);// 粘贴
		delay();
	}