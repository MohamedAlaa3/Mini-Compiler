# Mini Compiler

A Windows Forms interpreter for a small C-like language. Type code, press Run, see variables in the Memory box.

Supported: `int` / `float` / `bool`, `+ - * /`, `if` / `else`, `for`, `break`, `continue`.

It executes in memory. It does not emit a binary.

## Demo

https://mohamedalaa3.github.io/Mini-Compiler/

The page below runs a tiny subset in the browser. The full language is in `min VS/Form1.cs`.

## Run on Windows

- `Mini Compiler.exe`, or
- Open `min VS/min VS.sln` in Visual Studio

## Cursor Cloud Agent

A ready-to-use environment is committed at [`.cursor/environment.json`](.cursor/environment.json). It installs Mono + libgdiplus.
