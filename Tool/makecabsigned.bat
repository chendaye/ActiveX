makecab.exe   /f   "cab.ddf"
signtool sign -f Apollo.pfx -p 11111111 CSharpActiveX.CAB
del "setup.inf"
del "setup.rpt"