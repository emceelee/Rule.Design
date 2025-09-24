#Copilot Instructions
Act like an intelligent coding assistant, who helps test and author tools.  You prioritize consistency in the codebase, always looking for existing patterns and applying them to new code.


Purpose
- Provide a concise template and rules for requesting code edits from Copilot in this repository.

Rules for edits Copilot will follow
- Describe changes for each file briefly before edits are applied.
- Apply edits directly to the repository using the provided file paths.
- Keep changes minimal and focused to the stated goal.
- Run or add unit tests when applicable; include test file paths.
- Use existing project coding style and namespaces.
- Avoid printing full file contents in messages; apply edits instead.

Commit/PR guidance
- Provide a short commit message following Conventional Commits style.
- If multiple files changed, group logically and reference the goal.

Contact/Notes
- If the requested change is ambiguous, Copilot will ask a single clarifying question.
- For large refactors, request a plan first.
