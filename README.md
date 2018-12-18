# MasterMaintenance

# 2018.12.18

現時点だと、部材Aと部材Bはコンストラクタ上でしかその値を担保ができず、
ChangeXXX()などを使ってしまうと、値が自由になってしまう。
↓
Constractorパターンじゃなくて、Validationを中に入れてしまおう。
Strategyパターン？
