# Pong_MachineLearning

# Play it now! 
https://buddhadbread.github.io/Pong_MachineLearning/

# About
This is an iteration of the classic pong game but the AI is taught to play using the AI technique reinforcement learning. TheUnity package called ML Agents was used to create this game. The AI is given a positive reward for every time it can hit the ball with the paddle, and a negative reward if they let the ball pass them and hit the wall. 

# Training
![image](https://user-images.githubusercontent.com/50385049/235554510-103b4e85-8490-44f6-b24b-1a0c57c208bc.png)

Training was done in parallel as the AI Agent played against itself towards a wall.

![image](https://user-images.githubusercontent.com/50385049/235554615-3cc7a26d-2c2f-44df-90f3-b1efb2657fb3.png)

The AI was trained with gradual increasing speed over time. During the big spikes speed was changed and you can see the rewards obtain dropsquick but eventually they learn to hit the ball back at the desired speed. 

The final game uses a Neural Network model as a brain that have been trained for 5 hours. 

More documentation can be found in the pdf.
