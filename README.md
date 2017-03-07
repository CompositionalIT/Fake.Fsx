# Fake.Fsx
A FAKE extension module for working with FSX files.

# Install
Add this line to your `paket.dependencies`:

```
github CompositionalIT/Fake.Fsx
```

# Usage

Here is an example build script located at the project root:

```fsharp
#load "./paket-files/CompositionalIT/Fake.Fsx/Fake.Fsx.fsx"
open Fake
open Fake.Fsx

Target "ValidateScripts" (fun _ ->
    ValidateScripts [ "src/Script1.fsx"; "Script2.fsx" ])

// The rest of the script...

RunTargetOrDefault "ValidateScripts"
```

If any of the named scripts fail to compile, then an exception will be thrown and the build will fail.
