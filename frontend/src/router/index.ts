import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
const Template = () => import("../views/Template.vue");
const Home = () => import("../views/Home.vue");
const VIN = () => import( "../views/VIN.vue");

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Template",
    component: Template,
    children: [
      {
        path: "",
        name: "Home",
        component: Home
      },
      {
        path: "/:vin",
        name: "VIN",
        component: VIN
      },
    ]
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
