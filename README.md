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
2. Escalar a aplicacao de servico de transferencia a zero
3. Observar os logs da api e do sidecar
4. Ainda dentro do periodo do circuit breaker escalar o pod do servico de transferencia de volta para 1
5. Observar se o retorno vem para a api-transferencia

Para escalar o pod para zero `kubectl scale --replicas=0 deployment my-app`
