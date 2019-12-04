import os


def format_csharp_data_to_code2seq(data_path):
	snippets = ['{}.cs'.format(i) for i in range(1000)]
	for snip in snippets:
		print(snip)
	
	data = []
	
	for i in range(len(snippets)):
		snippet_path = os.path.join(os.path.join(data_path, 'snippets'), snippets[i])
		
		with open(snippet_path) as f:
			data += [' '.join(f.read().replace('\n', ' ').split())]
			
	with open('source.txt', 'w') as f:
		for item in data:
			f.write("%s\n" % item)
	
	
if __name__ == '__main__':
	format_csharp_data_to_code2seq('./data/C#')
