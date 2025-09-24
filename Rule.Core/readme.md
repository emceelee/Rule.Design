Rule.Core — Project structure and Copilot guidance

Purpose
- Core rule-engine library. Defines rule interfaces, base rule types, registry, and runtime behavior used across the solution.

File structure (what to edit and why)
- RuleRegistry.cs
  - Central registry and execution entrypoint. Responsible for registering rules, building rule sets, and executing evaluations.
- RuleSet.cs
  - Logical grouping of rules. Implements evaluation flow for a set of rules and aggregation of results.
- Rule.cs
  - Base/abstract rule implementation. Typical place to put common helper logic used by concrete rules.
- RuleResult.cs
  - Represents the outcome of a rule evaluation: success/failure, messages, severity, and optional payload.
- Interface/IRule.cs
  - Public contract for a rule. Defines input, output, and evaluation method signature.
- Interface/IRuleResult.cs
  - Contract for rule results used throughout the engine.
- Other files
  - Helpers, extensions, and internal utilities live alongside these core files. Keep related helpers next to the types they support.

Coding conventions & expectations
- Keep public API stable. Avoid breaking changes to interfaces and public types without updating dependent projects.
- Use generics consistently: T for input type, TResult or TOutput for result/payload types.
- Favor small, single-responsibility methods on core types; complex rule logic belongs to concrete rule implementations in other projects.
- Add XML documentation to public types and methods.
- Include unit tests for changes that affect execution flow or public contracts.

How to request edits from Copilot for this project (template)
- Goal: One-line desired outcome.
- Files: Full path(s) to file(s) to change (e.g., Rule.Core/RuleRegistry.cs).
- Change summary: 1–2 short bullets describing the change for each file.
- Constraints: Style, framework, testing, backwards-compatibility requirements.
- Output behavior: "apply edits directly" (preferred) or "show diff".

Example prompt (use this when asking Copilot to modify code here):
- Goal: Add a thread-safe cache to RuleRegistry to memoize evaluated RuleSet results for identical inputs.
- Files: c:\\Users\\matthew.lee\\source\\repos\\Rule.Design\\Rule.Core\\RuleRegistry.cs
- Change summary: Add a ConcurrentDictionary cache keyed by RuleSet id + input hash; update Execute to check cache before computing and store results after evaluation.
- Constraints: Keep public API unchanged; ensure thread-safety; add unit tests for concurrent access.
- Output behavior: apply edits directly.

Small-edit best practices for contributors
- Keep changes minimal and focused to the stated goal.
- When adding behavior used by other projects, update those projects' tests or add compatibility notes.
- If a change affects the public contract, include a short migration note and bump the version in documentation.

If uncertain
- Ask a single clarifying question before making edits. For large refactors, produce a short plan first.

End