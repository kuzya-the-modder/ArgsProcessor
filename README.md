# Argument Processor
- version : v.2.1 release (19.05.2024 :: Refactor)
## Changelist:
- Added CLI Debugger `debugar`
> Build Debuger/Debugger.csproj. Debugger.exe is debugar.exe, place it in one of your $env:PATH vars 
- Added Node Path processor.
> in: (debugar node node node2) -> out: [node node node2]
- Argument values can now have spaces
> in: (debugar -arg C:\Program Files) -> out: [arg, C:\Program Files])
- Now if certain arg/flag is already present, next will override it.
> in: (debugar -keyf -keyf value) -> out: [keyf, value]
- Fixed flag processing when is first/last element. `flags work ok now anywhere`
