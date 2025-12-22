Instruções iniciais do setup de teste local

** Data das instruções 10-12-2025 **
1. Ter o docker instalado
2. Ativar o kubernetes do docker
3. Instalar e configurar o dapr cli (https://docs.dapr.io/getting-started/install-dapr-cli)
---
Construir a aplicação containerizada
Rodar direto no docker pra ver se está ok
docker run -p [HOST_PORT]:[CONTAINER_PORT] [IMAGE_NAME]
* HOST_PORT: Porta na maquina local
* CONTAINER_PORT: Porta exposta pelo container
---
Quando voce tiver no ambiente do k8s o certo vai ser dois containeres no mesmo pod pra fazer o intermedio!
---
Nos deployments do k8s as portas expostas localmente para teste sao
9001: api-transferencia
9002: api-contacorrente
9101: servico-transferencia
---
Para testar a resiliencia
1. Configurar o circuit breaker (no Dapr) apontando para a api-transferencia
2. Colocado rate limit na aplicacao que simula faz a consulta de saldo
3. Observar os logs da api e do sidecar
   kubectl logs <host da api transferencia> -f
   kubectl logs <host da api transferencia> daprd -f
5. Observar se o retorno vem para a api-transferencia depois do periodo do rate limit
---
O tópico sns-transferencia pode ser utilizado para notificar outros sistemas sobre a transferencia
---
As credenciais da aplicação para acesso a servicos AWS estao associadas a um IAM user, foi gerada uma access key para este usuario apenas para simplicidade do processo (estamos rodando localmente dentro do k8s do docker), mas para nao haver vazamento de credenciais e uso indevido da chave elas foram incluidas em uma secret no k8s, e o arquivo que contém estas secrets de deploy foi incluido no .gitignore
Algumas informações nao necessariamente sao sensiveis, mas nao é recomendavel expo-las, como por exemplo, o numero da conta AWS. Portanto o dados que contem o numero da conta AWS tambem foram incluidas na secret k8s
