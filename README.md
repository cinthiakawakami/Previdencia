# Previdencia
Desenvolvimento de sistema para que participantes dos planos de previdência privada consigam alterar o perfil (carteira) de investimento que seus ativos estão investidos.

Utilizado um modelo DDD com a camada de apresentação em ASP.NET MVC, utilizando Razor com bootstrap (modelo padrão do Visual Studio). Para manipulação de dados, banco de dados SQL server e Entity Framework. Também foram utilizados AutoMapper e IoC com Ninject.

No sistema atualmente é possível cadastrar e autenticar um usuário. O usuário autenticado pode realizar várias açoes, dentre elas: Responder o formulário de perfil de investidor, verificar qual a sua carteria e solicitar a inclusão de uma carteira de acordo com seu perfil, solicitar a alteração da carteira, verificar as solicitações já realizadas e procurar uma alteração específica com um protocolo.

No fluxo principal, o usuário loga no sistema e, caso já tenha uma carteira associada a sua conta, pode solicitar a alteração.
No caso deste sistema, o usuário "maria@maria.com" de senha "123456" é o usuário que pode realizar este pedido, já que os outros usuários ainda não possuem carteira associada. No momento, somente as carteiras que estão de acordo com o perfil são disponibilizadas para serem escolhidas.

Todos os novos usuarios podem solicitar a inclusão de uma carteira, mas somente se tiverem respondido o formulário de pefil de investidor.

O sistema ainda não está programado para efetivamente incluir ou alterar a carteira, somente gerando as solicitações, que tem status que deverão poder serem alterados e a solicitação ser efetivamente feita num desenvolvimento posterior. A associação de uma carteira ao usuario citado acima foi feita manualmente.

Além deste fluxo principal, o usuário logado pode ver todas as suas solicitações e responder ou alterar as respostas de seu perfil de investidor. A pesquisa via protocolo pode ser feita mesmo não estando logado.

Melhorias futuras

Implementar a efetivação da inclusão ou alteração de carteira e não somente da solicitação.

Melhorar a parte do usuário, foi feita apenas um registro e autenticação simples com hash simples, sem opções de mudança de senha, recuperação de senha, dentre outros.

Melhorar os status e tipos, utilizando Enums ou mesmo classes e tabelas, dependendo de sua utilização.

Melhorar o design, front-end e ux, tendo sido utilizados templates padrão.

Melhoria de fluxos e melhor comunicação com o usuário, enviando por e-mail.

Melhoria de tratamento de erros.

Criação de log de eventos e log e erros.
