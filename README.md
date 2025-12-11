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


