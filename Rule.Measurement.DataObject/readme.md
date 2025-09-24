# Rules.Measurement.DataObject

High-level description
This project contains simple Data Object (DO) classes used by the Rules.Measurement domain. The classes are lightweight POCOs (plain old CLR objects) that represent measurement-related data (for example gas volumes and associated metadata). These DOs are intended for transport, serialization, mapping, and unit-aware calculations performed by other layers.

Contents and structure
- GasVolumeDO.cs — Represents a gas measurement record (meter id, time range, volume/energy and corresponding UOM enums).
- (Other DO files) — Additional data objects follow the same pattern: properties only, no business logic.
- Enums (in this project or shared library) — Unit and code enums referenced by DOs (UnitTimeCode, GasVolumeUom, GasEnergyUom).

Conventions
- DO classes should remain immutable-friendly and contain only properties (no behavior).
- Keep naming and types consistent with domain contracts used by service and rule layers.
- Avoid adding dependencies; keep this project lightweight and serializable-friendly.

Build / usage notes
- This is a class library project. Reference it from consumer projects that implement rules, mapping, or transport.
- For tests and serialization, use your solution's standard test and CI setup.
- If you add new DOs, update any mapping profiles or serialization contracts that consume them.

Contact
For questions about domain meanings or enum definitions, consult the Rules.Measurement domain owners or README files in adjacent projects.
