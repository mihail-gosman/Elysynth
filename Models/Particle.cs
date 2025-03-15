using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Particle
    {
        string name;
        double mass;
        double charge;
        double xPos;
        double yPos;
        double xVel;
        double yVel;
        double xAcc;
        double yAcc;

        public Particle()
        {

        }

        public Particle(double mass, double charge, double xPos, double yPos, double xVel, double yVel, double xAcc, double yAcc, string name)
        {
            this.mass = mass;
            this.charge = charge;
            this.xPos = xPos;
            this.yPos = yPos;
            this.xVel = xVel;
            this.yVel = yVel;
            this.xAcc = xAcc;
            this.yAcc = yAcc;
            this.name = name;
        }

        public void SetPosition(double xPos, double yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void setVelocity(double xVel, double yVel)
        {
            this.xVel = xVel;
            this.yVel = yVel;
        }

        public void SetAcceleration(double xAcc, double yAcc)
        {
            this.xAcc = xAcc;
            this.yAcc = yAcc;
        }

        public void setMass(double mass)
        {
            this.mass = mass;
        }

        public void setCharge(double charge)
        {
            this.charge = charge;
        }

        public double[] GetPosition()
        {
            double[] position = { xPos, yPos };
            return position;
        }

        public double[] GetVelocity()
        {
            double[] velocity = { xVel, yVel };
            return velocity;
        }
        public double[] GetAcceleration()
        {
            double[] acceleration = { xAcc, yAcc };
            return acceleration;
        }

        public double GetCharge()
        {
            return charge;
        }

        public double GetMass()
        {
            return mass;
        }


        public void Update(double deltaTime)
        {
            // Update the x position using the kinematic equation: x = x0 + v0 * t + 0.5 * a * t^2
            xPos += xVel * deltaTime + 0.5 * xAcc * Math.Pow(deltaTime, 2);

            // Update the y position using the kinematic equation: y = y0 + v0 * t + 0.5 * a * t^2
            yPos += yVel * deltaTime + 0.5 * yAcc * Math.Pow(deltaTime, 2);
        }

        public void ApplyForce(double forceX, double forceY)
        {
            // Calculate the acceleration from the applied force using Newton's second law: F = m * a => a = F / m
            double accX = forceX / mass;
            double accY = forceY / mass;

            // Update the particle's acceleration
            xAcc += accX;
            yAcc += accY;
        }

        public override string ToString()
        {
            return "Particle: mass=" + mass + ", charge=" + charge + ", xPos=" + xPos + ", yPos=" + yPos + ", xVel=" + xVel + ", yVel=" + yVel + ", xAcc=" + xAcc + ", yAcc=" + yAcc;
        }

    } 
}
