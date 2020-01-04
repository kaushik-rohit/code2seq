public static <A extends Annotation> AnnotationValues<A> createAnnotation(Class<A> type, JCAnnotation anno, final JavacNode node) {
		Map<String, AnnotationValue> values = new HashMap<String, AnnotationValue>();
		List<JCExpression> arguments = anno.getArguments();
		
		for (JCExpression arg : arguments) {
			String mName;
			JCExpression rhs;
			java.util.List<String> raws = new ArrayList<String>();
			java.util.List<Object> guesses = new ArrayList<Object>();
			java.util.List<Object> expressions = new ArrayList<Object>();
			final java.util.List<DiagnosticPosition> positions = new ArrayList<DiagnosticPosition>();
			
			if (arg instanceof JCAssign) {
				JCAssign assign = (JCAssign) arg;
				mName = assign.lhs.toString();
				rhs = assign.rhs;
			} else {
				rhs = arg;
				mName = "value";
			}
			
			if (rhs instanceof JCNewArray) {
				List<JCExpression> elems = ((JCNewArray) rhs).elems;
				for (JCExpression inner : elems) {
					raws.add(inner.toString());
					expressions.add(inner);
					if (inner instanceof JCAnnotation) {
						try {
							@SuppressWarnings("unchecked")
							Class<A> innerClass = (Class<A>) Class.forName(inner.type.toString());
							
							guesses.add(createAnnotation(innerClass, (JCAnnotation) inner, node));
						} catch (ClassNotFoundException ex) {
							guesses.add(calculateGuess(inner));
						}
					} else {
						guesses.add(calculateGuess(inner));
					}
					positions.add(inner.pos());
				}
			} else {
				raws.add(rhs.toString());
				expressions.add(rhs);
				if (rhs instanceof JCAnnotation) {
					try {
						@SuppressWarnings("unchecked")
						Class<A> innerClass = (Class<A>) Class.forName(rhs.type.toString());
						
						guesses.add(createAnnotation(innerClass, (JCAnnotation) rhs, node));
					} catch (ClassNotFoundException ex) {
						guesses.add(calculateGuess(rhs));
					}
				} else {
					guesses.add(calculateGuess(rhs));
				}
				positions.add(rhs.pos());
			}
			
			values.put(mName, new AnnotationValue(node, raws, expressions, guesses, true) {
				@Override public void setError(String message, int valueIdx) {
					if (valueIdx < 0) node.addError(message);
					else node.addError(message, positions.get(valueIdx));
				}
				
				@Override public void setWarning(String message, int valueIdx) {
					if (valueIdx < 0) node.addWarning(message);
					else node.addWarning(message, positions.get(valueIdx));
				}
			});
		}
		
		for (Method m : type.getDeclaredMethods()) {
			if (!Modifier.isPublic(m.getModifiers())) continue;
			String name = m.getName();
			if (!values.containsKey(name)) {
				values.put(name, new AnnotationValue(node, new ArrayList<String>(), new ArrayList<Object>(), new ArrayList<Object>(), false) {
					@Override public void setError(String message, int valueIdx) {
						node.addError(message);
					}
					@Override public void setWarning(String message, int valueIdx) {
						node.addWarning(message);
					}
				});
			}
		}
		
		return new AnnotationValues<A>(type, values, node);
	}