# Sistema de Heranças Tecnológicas

Alguns avanços criados em épocas antigas podem ser reaproveitados por civilizações posteriores. As classes do namespace `UltraWorldAI.Discovery` registram tecnologias no `TechTimelineSystem` permitindo que suas versões evoluídas sejam herdadas.

Para incluir uma nova tecnologia que possa ser herdada:

1. Crie uma instância de `ConceptualTech` usando `TechCreator.CreateTech`.
2. Adicione a instância ao `TechCreator.TechPool`.
3. Utilize `TechReawakening.Reinterpret` para reativar esse conhecimento em outras épocas.

O sistema busca manter compatibilidade com módulos místicos, permitindo combinações como `SacredTechFusion`.
