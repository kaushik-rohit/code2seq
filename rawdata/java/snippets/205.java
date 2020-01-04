public <T> T toBean(T bean, boolean isToCamelCase) {
		BeanUtil.fillBeanWithMap(this, bean, isToCamelCase, false);
		return bean;
	}