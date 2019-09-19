using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrABENECi
{
    class Genetic_algorithm
    {
        public static int MUTATION_RATE_THRESH = 4;
        public static int IMPROVING_PARENT_CYCLES = 2;
        public static int last_id;

        public static Agent[] Evolve(Agent[] Population)
        {
            last_id++;
            Agent[] New_population = new Agent[Population.Length];
            New_population[0] = Get_best_agent(Population);
            New_population[0].id = 0 + last_id;

            Agent[] Halved_population = Kill_the_weak(Population);

            for (int i = 1; i < Population.Length; i++)
            {
                bool[] temp_cache = new bool[Halved_population.Length]; 
                int mother_num = Get_cached_random(ref temp_cache);
                int father_num = Get_cached_random(ref temp_cache);
                for (int j = 0; j < IMPROVING_PARENT_CYCLES; j++)
                {
                    int rand_mom = Get_cached_random(ref temp_cache);
                    int rand_dad = Get_cached_random(ref temp_cache);
                    if (Halved_population[mother_num].fitness < Halved_population[rand_mom].fitness)
                        mother_num = rand_mom;
                    if (Halved_population[father_num].fitness < Halved_population[rand_dad].fitness)
                        father_num = rand_dad;
                }
                New_population[i] = new Agent(Halved_population[mother_num], Halved_population[father_num]);
                New_population[i].id = i + last_id;
            }

            last_id += Population.Length;
            return New_population;
        }

        public static int Get_cached_random(ref bool[] cache)
        {
            int rand_num = Logic.rand.Next(0, cache.Length);
            if (cache[rand_num] == true)
                while (cache[rand_num] == true)
                    rand_num = (rand_num + 1) % cache.Length;
            cache[rand_num] = true;
            return rand_num;
        }

        public static Agent Get_best_agent(Agent[] agents)
        {
            int best_fitness = -200;
            Agent best_agent = null;
            foreach (Agent agent in agents)
            {
                if (agent.fitness > best_fitness)
                {
                    best_fitness = agent.fitness;
                    best_agent = agent;
                }
            }
            return best_agent;
        }

        public static Agent[] Kill_the_weak(Agent[] Population)
        {
            Agent[] Halved_population = new Agent[Population.Length / 2];
            bool[] used_flag = new bool[Population.Length];

            for (int i = 0; i < Halved_population.Length; i++)
            {
                int rand_num1 = Get_cached_random(ref used_flag);
                int rand_num2 = Get_cached_random(ref used_flag);
                Halved_population[i] = Compare(Population[rand_num1], Population[rand_num2]);
            }

            return Halved_population;
        }

        static Agent Compare(Agent agent1, Agent agent2)
        {
            if (agent1.fitness > agent2.fitness)
                return agent1;
            else
                return agent2;
        }
    }
}
