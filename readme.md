# LANCHERIA ![Static Badge](https://img.shields.io/badge/version-0.1-blue)

Este é o "remake"/melhoria de um projeto realizado durante um processo seletivo.
Este conterá uma aplicação para uma startup fictícia no ramo de alimentos, abrangendo fullstack web e mobile##

1. [MOTIVAÇÃO](#1-motivação)
2. [TECNOLOGIAS](#2-tecnologias)
3. [O PROJETO](#3-o-projeto)

## 1. MOTIVAÇÃO

A motivação por trás da realização deste projeto é, além de uma comprovação de habilidades válida par o portifólio, a construção e potencial aprendizado contidos em um projeto real, possibilitando mensurar com mais precisão, desfalques e falta de conhecimento técnico.

## 2. TECNOLOGIAS

Algumas das tecnologias utilizadas no projeto

### 2.1 BACK-END

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)

### 2.2 FRONT-END

![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
![Redux](https://img.shields.io/badge/redux-%23593d88.svg?style=for-the-badge&logo=redux&logoColor=white)
![SASS](https://img.shields.io/badge/SASS-hotpink.svg?style=for-the-badge&logo=SASS&logoColor=white)

### 2.3 MOBILE

![React Native](https://img.shields.io/badge/react_native-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
![Expo](https://img.shields.io/badge/expo-1C1E24?style=for-the-badge&logo=expo&logoColor=#D04A37)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)

### 2.4 TESTES

![Jest](https://img.shields.io/badge/-jest-%23C21325?style=for-the-badge&logo=jest&logoColor=white)

### 2.5 DESIGN

![Figma](https://img.shields.io/badge/figma-%23F24E1E.svg?style=for-the-badge&logo=figma&logoColor=white)

### 2.6 LINGUAGENS BASE

![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)

## 3. O PROJETO

### 3.1. PROPOSTA

- Somos uma startup do ramo de alimentos e precisamos de uma aplicação web para gerir nosso negócio
- Nossa especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.

### 3.2. ESPECIFICAÇÕES

0. Implementar aplicação em fullstack web e mobile

1. O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõe o lanche.

2. O cliente pode personalizar seu lanche e escolher os ingredientes que desejar. Nesse caso, o preço do lanche também será calculado pela soma dos ingredientes.

3. O sistema deverá possuir autenticação para clientes e administradores

4. Um administrador do sistema poderá modificar o preço do ingredientes

5. O cliente poderá realizar o pedido

6. Implementar todos os passos de compra e confirmação do pedido

7. O administrador deve possuir um dashboard com informações sobre vendas, pedidos feitos, lanches e ingredientes mais pedidos

### 3.3. TABELA DE PRECOS

| INGREDIENTE         | VALOR   |
| ------------------- | ------- |
| Alface              | R$ 0.40 |
| Bacon               | R$ 2.00 |
| Hambúrguer de carne | R$ 3.00 |
| Ovo                 | R$ 0.80 |
| Queijo              | R$ 1.5  |

### 3.4. TABELA DE LANCHES

| LANCHE      | INGREDIENTES                             |
| ----------- | ---------------------------------------- |
| X-Bacon     | Bacon, hambúrguer de carne e queijo      |
| X-Burger    | Hambúrguer de carne e queijo             |
| X-Egg       | Ovo, hambúrguer de carne e queijo        |
| X-Egg Bacon | Ovo, bacon, hambúrguer de carne e queijo |

### 3.5. PROMOÇÕES

| PROMOÇÃO     | REGRA DE NEGÓCIO                                                                                                            |
| ------------ | --------------------------------------------------------------------------------------------------------------------------- |
| Light        | Se o lanche tem alface e não tem bacon, ganha 10% de desconto.                                                              |
| Muita carne  | A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...          |
| Muito queijo | A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...         |
| Inflação     | Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados. |
