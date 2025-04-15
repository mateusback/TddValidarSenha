# Experiência de uso do TDD

## Testes de validação de senha
```
TDD é uma metodologia de desenvolvimento de software onde os testes automatizados são escritos antes do código funcional. A ideia central é seguir um ciclo curto de desenvolvimento, conhecido como Red-Green-Refactor:

Red: Escreva um teste que falha (o código ainda não foi implementado).
Green: Escreva o código mínimo necessário para fazer o teste passar.
Refactor: Refatore o código para melhorar sua estrutura, mantendo os testes passando.
```
A implementação baseada no TDD seguiu a definição demonstrada pelo professor, primeiro foram implementados testes unitários (Facts no xUnit) para validar cada uma das regars de senhas. Inicialmente todos os testes falharam porque a classe de validação não existia, então ela foi criada e as regras foram implementadas uma a uma até os testes passarem, na seguinte sequência:
- Mínimo de 8 caracteres.
- Pelo menos uma letra maiúscula.
- Pelo menos uma letra minúscula.
- Pelo menos um número.
- Pelo menos um caractere especial (ex: !@#$%^&*).
- Não pode conter espaços em branco.

Com as regras implementadas e todos os testes passando, entramos na fase de Refactor, onde todas as validações - inicialmente definidas por vários IFs - foram alteradas para utilizar uma lista de regras pro regex, aumentado a performance da função. Além disso, também foram implementados mais testes unitários para validar uma grande quantidade de testes (Theory no xUnit).
Dessa forma, o desenvolvimento foi extremamente guiado com base nas regras necessárias para fazer o processo funcionar, facilitando a implementação.
