# Rules.Measurement.Validation

High-level description
This project contains validation logic for the Rules.Measurement domain. It provides validators and rule-checking components that ensure Data Objects (DOs) and inputs conform to domain constraints before processing by rule engines, mappings, or persistence layers.

Contents and structure
- Validators — Concrete validator classes for DOs (for example, GasVolumeDO validators) and other input models.
- Rules — Reusable validation rule classes and helpers encapsulating common checks (range checks, required fields, unit compatibility).
- Interfaces — Abstractions for validators and rules to allow DI and easy unit testing.
- Tests — Unit tests that verify validator behavior (may be in a sibling test project).
- Registration — DI registration helpers to wire validators into the application container.

Conventions
- Keep validators small and focused; one validator per DO or input model.
- Prefer composition of reusable rule components over duplicating logic.
- Validators should be deterministic and side-effect free.
- Use consistent error/result types (validation result objects or exceptions) across the project.

Build / usage notes
- This is a class library; reference it from service or API projects that must validate measurement data.
- Register validators with your IoC container (example: AddTransient<IValidator<T>, TValidator>).
- Add or update unit tests when adding new validators or rules.
- Keep validation messages and codes stable if external systems rely on them.

Contact
For domain-specific validation rules or to clarify business constraints, consult the Rules.Measurement domain owners.
