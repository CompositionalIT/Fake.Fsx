module Fake
#r "./../../../packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.FscHelper
open System.IO

module Fsx =
    let private validateScriptsWith compileF scripts =
        let path = Path.GetTempPath() </> Path.GetTempFileName() + ".dll"
        try
            compileF
                [ Out path
                  References [ @"System.Runtime" ]
                  FscHelper.Target TargetType.Library ]
                scripts
        finally DeleteFile path

    /// Compiles one or more FSX script files and discards the output assembly.
    /// Throws an exception if compilation fails.
    /// ## Parameters
    ///
    ///  - `scripts` - The FSX scripts to compile.
    let ValidateScripts scripts = validateScriptsWith Compile scripts

    /// Compiles one or more FSX script files and discards the output assembly.
    /// ## Parameters
    ///
    ///  - `scripts` - The FSX scripts to compile.
    ///
    /// ## Returns
    ///
    /// The exit status code of the compile process.
    let validateScripts scripts = validateScriptsWith compile scripts