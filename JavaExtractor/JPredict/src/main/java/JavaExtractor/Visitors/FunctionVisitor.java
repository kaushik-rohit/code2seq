package JavaExtractor.Visitors;

import JavaExtractor.Common.CommandLineValues;
import JavaExtractor.Common.Common;
import JavaExtractor.Common.MethodContent;
import com.github.javaparser.ast.Node;
import com.github.javaparser.ast.body.MethodDeclaration;
import com.github.javaparser.ast.visitor.VoidVisitorAdapter;

import java.io.FileWriter;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Arrays;

@SuppressWarnings("StringEquality")
public class FunctionVisitor extends VoidVisitorAdapter<Object> {
    private final ArrayList<MethodContent> m_Methods = new ArrayList<>();
    private final CommandLineValues m_CommandLineValues;

    public FunctionVisitor(CommandLineValues commandLineValues) {
        this.m_CommandLineValues = commandLineValues;
    }

    @Override
    public void visit(MethodDeclaration node, Object arg) {
    	visitMethod(node);
        super.visit(node, arg);
    }
    
    private void printMethod(MethodDeclaration node) {
    	StringBuilder sb = new StringBuilder();
    	sb.append(String.join(" ", Common.splitToSubtokens(node.getName())));
    	//sb.append(node.getName());
    	sb.append('|');
    	sb.append(node.toString().replaceFirst(node.getName(), "").replaceAll("\n", " ").replaceAll("\\s{2,}", " ").trim());
    	String filepath = "/home/rohit/projects/code2seq_r/JavaExtractor2/log.txt";
    	try(PrintWriter output = new PrintWriter(new FileWriter(filepath,true))) 
    	{
    	    output.printf("%s\n", sb.toString());
    	} 
    	catch (Exception e) {}
    	
    	System.out.println(sb.toString());
    }
    
    private void visitMethod(MethodDeclaration node) {
    	printMethod(node);
        LeavesCollectorVisitor leavesCollectorVisitor = new LeavesCollectorVisitor();
        leavesCollectorVisitor.visitDepthFirst(node);
        ArrayList<Node> leaves = leavesCollectorVisitor.getLeaves();

        String normalizedMethodName = Common.normalizeName(node.getName(), Common.BlankWord);
        ArrayList<String> splitNameParts = Common.splitToSubtokens(node.getName());
        String splitName = normalizedMethodName;
        if (splitNameParts.size() > 0) {
            splitName = String.join(Common.internalSeparator, splitNameParts);
        }

        if (node.getBody() != null) {
            long methodLength = getMethodLength(node.getBody().toString());
            if (m_CommandLineValues.MaxCodeLength > 0) {
                if (methodLength >= m_CommandLineValues.MinCodeLength && methodLength <= m_CommandLineValues.MaxCodeLength) {
                    m_Methods.add(new MethodContent(leaves, splitName));
                }
            } else {
                m_Methods.add(new MethodContent(leaves, splitName));
            }
        }
    }

    private long getMethodLength(String code) {
        String cleanCode = code.replaceAll("\r\n", "\n").replaceAll("\t", " ");
        if (cleanCode.startsWith("{\n"))
            cleanCode = cleanCode.substring(3).trim();
        if (cleanCode.endsWith("\n}"))
            cleanCode = cleanCode.substring(0, cleanCode.length() - 2).trim();
        if (cleanCode.length() == 0) {
            return 0;
        }
        return Arrays.stream(cleanCode.split("\n"))
                .filter(line -> (line.trim() != "{" && line.trim() != "}" && line.trim() != ""))
                .filter(line -> !line.trim().startsWith("/") && !line.trim().startsWith("*")).count();
    }

    public ArrayList<MethodContent> getMethodContents() {
        return m_Methods;
    }
}
